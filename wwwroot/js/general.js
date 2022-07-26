// slidebar
let dropdownBtn = document.getElementsByClassName('dropdown-container');
let activeDropdownBtn = document.querySelector('.slidebar .btn');
let rotate_arrow = document.querySelector('.slidebar nav .arrow');
activeDropdownBtn.addEventListener('click', openerInformation);

function openerInformation()
{
    if(dropdownBtn[0].style.height != '0px')
    {
        dropdownBtn[0].style.height = '0';
        activeDropdownBtn.classList.remove("btn-active");
        rotate_arrow.style.transform = 'rotate(0deg)';
    }
    else
    {
        let dropdownClient = document.querySelector(".dropdown-client");
        dropdownBtn[0].style.height = dropdownClient.clientHeight + "px";
        activeDropdownBtn.classList.add("btn-active");
        rotate_arrow.style.transform = 'rotate(180deg)';
    }
}
// slidebar end


// open slidebar
let slidebar = document.querySelector('.slidebar');
let btn_menu = document.querySelector('.btn_menu');
let header = document.querySelector('header');
btn_menu.addEventListener('click', () => {
    console.log(header.before.opacity);
    if(btn_menu.children[0].className == 'first_line'){
        btn_menu.children[0].classList.add('first_line_active');
        btn_menu.children[1].classList.add('last_line_active');
        slidebar.classList.add('slidebar_active');
        header.classList.add('header_active');
    }  
    else{
        btn_menu.children[0].classList.remove('first_line_active');
        btn_menu.children[1].classList.remove('last_line_active');
        slidebar.classList.remove('slidebar_active');
        header.classList.remove('header_active');
    }  
});

// open slidebar end






