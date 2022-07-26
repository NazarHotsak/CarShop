
// slider start
let scroll_slider = document.querySelector('.scroll_slider');
let img_slide = document.getElementsByClassName('img_slide');

let isMousedown = false;
let startX = 0;


let Offset = 0;
const ImgMarginRight = 8;
let ImgWidth = 0;
let FullWidthOfImg = 0;
let Steps = 0;
let SlidersSrc = [];
let ScrollWidth;
let isTimerWork = false;
let maxOffset = 0;
let timer;

function Init() {
    FullWidthOfImg = img_slide[0].clientWidth + ImgMarginRight;
    ScrollWidth = scroll_slider.clientWidth;
    Offset = 0;
    ReplaceSrcForImages();
    scroll_slider.style.transition = "none";
    scroll_slider.style.transform = `translate3d(-${Offset}px,0,0)`;
    maxOffset = FullWidthOfImg * img_slide.length - ScrollWidth;

    if (isTimerWork == false) {
        if (maxOffset > FullWidthOfImg) {
            isTimerWork = true;
            timer = window.setInterval(Scroll, 3000);
        }
    }
    else {
        if (maxOffset < FullWidthOfImg) {
            isTimerWork = false;
            clearInterval(timer);
        }
    }
}

function SaveSrc() {
    for (let index = 0; index < img_slide.length; index++) {
        SlidersSrc[index] = img_slide[index].src;
    }
}

function ReplaceSrcForImages() {
    for (let i = 0; i < img_slide.length; i++) {
        if (Steps >= img_slide.length || Steps < 0) {
            Steps = 0;
        }
        img_slide[i].src = SlidersSrc[Steps];
        Steps++;
    }
    Steps = 0;
    SaveSrc();
}

SaveSrc();
Init();


scroll_slider.addEventListener('mousedown', (event) => {
    if (isTimerWork) {
        clearInterval(timer);
    }
    isMousedown = true;
    scroll_slider.style.transition = "none";
    startX = event.layerX;
});

scroll_slider.addEventListener('mouseup', (e) => mouseUpDown(e));
scroll_slider.addEventListener('mouseout', (e) => mouseUpDown(e));
scroll_slider.addEventListener('mousemove', (event) => {
    if (isMousedown) {
        scroll_slider.style.transform = `translate3d(${(Offset - (event.layerX - startX)) * -1}px,0,0)`;
    }
});

function mouseUpDown(e) {
    if (isMousedown) {
        isMousedown = false;
        nextSlide(e);
        if (isTimerWork) {
            timer = window.setInterval(Scroll, 3000);
        }
    }
}
function nextSlide(e) {
    scroll_slider.style.transition = "transform .7s";

    if (startX > e.layerX && startX - e.layerX >= FullWidthOfImg / 4 * 3 && maxOffset - FullWidthOfImg / 3 * 2 > Offset) {
        Offset += FullWidthOfImg;
        Steps++;
    }
    else if (e.layerX - startX >= FullWidthOfImg / 4 * 3 && Offset != 0 && maxOffset > FullWidthOfImg) {
        Offset -= FullWidthOfImg;
        Steps--;
    }
    else if (maxOffset < FullWidthOfImg) {
        if (startX > e.layerX && startX - e.layerX >= FullWidthOfImg / 8 && Offset < FullWidthOfImg * img_slide.length - ScrollWidth) {
            Offset += FullWidthOfImg * img_slide.length - ScrollWidth;
        }
        else if (e.layerX - startX >= FullWidthOfImg / 8 && Offset != 0) {
            Offset -= FullWidthOfImg * img_slide.length - ScrollWidth;
        }
    }

    scroll_slider.style.transform = `translate3d(${Offset * -1}px,0,0)`;
}
//img_slide.length == 3 && FullWidthOfImg > FullWidthOfImg * img_slide.length - ScrollWidth


function Scroll() {

    //console.log(Offset + "   " + Steps);

    Offset += FullWidthOfImg;

    if ((img_slide.length * FullWidthOfImg) - ScrollWidth <= Offset) {
        Offset = 0;
        scroll_slider.style.transition = "none";

        ReplaceSrcForImages();

        setTimeout(Scroll, 50);
    }
    else {
        scroll_slider.style.transition = "transform .7s";
        Steps++;
    }

    scroll_slider.style.transform = `translate3d(-${Offset}px,0,0)`;
}

window.addEventListener('resize', Init);
// slider end


// card tab start
let card_type = document.querySelectorAll('.card_type');
let card_imformation = document.querySelectorAll('.card_imformation');
let sequentialActiveNumber = 0;

function cardActive(newSequentialActiveNumber) {
    card_type[sequentialActiveNumber].classList.remove('active');
    card_imformation[sequentialActiveNumber].classList.remove('active');
    card_type[newSequentialActiveNumber].classList.add('active');
    card_imformation[newSequentialActiveNumber].classList.add('active');
    sequentialActiveNumber = newSequentialActiveNumber;
}
// card tab end
