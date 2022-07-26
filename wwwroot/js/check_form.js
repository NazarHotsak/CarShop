
function checkData(event){
    
    removeAllWarning(event.currentTarget);

    let inputs = [];
    
    let isValid = true;

    for (let i = 0; i < event.currentTarget.children.length; i++) {
        
        if (event.currentTarget.children[i].localName == "input") {
            inputs.push(event.currentTarget.children[i]);   
        }
    }

    for (let i = 0; i < inputs.length; i++) {

        if(typeof(inputs[i].dataset.dataType) === undefined){
            continue;
        }

        let warning = IsValid(inputs[i].dataset.dataType, inputs[i].value)
        
        if (warning != "") {
            isValid = false;
            inputs[i].before(createWarning(warning + "!"));
            inputs[i].classList.add("warning_input");
        }
    }


    if (isValid) {
        return true;
    }



    if (event.preventDefault) {
        event.preventDefault();
    } else {
        event.returnValue = false;
    }

    console.log(event);
}

function IsValid(tadaType, value = ""){

    value = value.replaceAll(" ", "");
    switch (tadaType) {
        case "name":
            if (value === "") {
                return "Введіть своє ім'я";        
            }
            else if(value.match(/[^\p{Alpha}]/u) != null){
                return "Вводьте тільки літери";
            }
            break;
        case "phoneInUA":
            if (value === "") {
                return "Введіть свій номер";        
            }
            else if (value.length < 10) {
                return "замало цифр";
            }
            else if (value.length > 13) {
                return "забагато цифр";
            }
            else if(value.match(/[^0-9^+]/) != null || value.indexOf("+", 0) > 0){
                return "Вводьте тільки цифри і + на початку";
            }        
            break;
    }    
    return "";
}

function removeAllWarning(parent){
    
    for (let i = 0; i < parent.children.length; i++) {
        parent.children[i].classList.remove("warning_input");
        if (parent.children[i].localName == "div" && parent.children[i].classList == "warning_text") {
            parent.removeChild(parent.children[i]);   
            i--;
        }
    }    
}

function createWarning(text){
    let div = document.createElement("div");
    div.innerHTML = text;
    div.classList.add("warning_text");
    return div;
}