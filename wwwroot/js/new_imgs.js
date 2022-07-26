let choose = document.querySelector(".choose");
let chose_imgs_wrapper = document.querySelector(".chose_imgs_wrapper");

choose.addEventListener("change", updateImgsDisplay);

function updateImgsDisplay() {
    removeAllChildren(chose_imgs_wrapper);

    const files = choose.files;

    console.dir(files);

    if (files.length === 0) {
        let result = document.createElement("p");
        result.classList.add("imgs_dont_choose");
        result.innerHTML = "Фото не вибрано";
        chose_imgs_wrapper.appendChild(result);
    }
    else {
        for (let i = 0; i < files.length; i++) {

            let viewImg = document.createElement("div");
            viewImg.classList.add("chose_imgs");

            let info = document.createElement("div");
            let fileName = document.createElement("p");
            fileName.innerHTML = `file name: ${files[i].name},`;
            let size = document.createElement("p");
            size.innerHTML = `size: ${returnFileSize(files[i].size)}`;
            info.appendChild(fileName);
            info.appendChild(size);

            viewImg.appendChild(info);

            let imgContainer = document.createElement("div");
            imgContainer.classList.add("small_img");
            let img = document.createElement("img");
            img.src = URL.createObjectURL(files[i]);
            imgContainer.appendChild(img);

            viewImg.appendChild(imgContainer);

            chose_imgs_wrapper.appendChild(viewImg);
        }
    }
}

function removeAllChildren(parent) {
    while (parent.firstChild) {
        parent.removeChild(parent.firstChild);
    }
}

function returnFileSize(number) {
    if (number < 1024) {
        return number + 'bytes';
    } else if (number > 1024 && number < 1048576) {
        return (number / 1024).toFixed(1) + 'KB';
    } else if (number > 1048576) {
        return (number / 1048576).toFixed(1) + 'MB';
    }
}