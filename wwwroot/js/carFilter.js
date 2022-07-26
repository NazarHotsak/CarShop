let GearboxType = document.getElementsByClassName("GearboxType")[0];
let submitLink = document.getElementsByClassName("Btn_submit")[0];
let BrandType = document.getElementsByClassName("BrandType")[0];
let DriveType = document.getElementsByClassName("DriveType")[0];
let FullDuty = document.getElementsByClassName("FullDuty")[0];
let PriceFrom = document.getElementsByClassName("Price")[0];
let PriceTo = document.getElementsByClassName("Price")[1];
let Cut = document.getElementsByClassName("Cut")[0];
let StatusCar0 = document.getElementsByClassName("StatusCar")[0];
let StatusCar1 = document.getElementsByClassName("StatusCar")[1];
let StatusCar2 = document.getElementsByClassName("StatusCar")[2];

const startValueOfSortParameters = "SortBy-";
const MaxPrice = 2450000;
const MinPrice = 1;
const From = 0;
const To = 1;
let URLOk = true;

class IndexesSortParameters {
    StartIndexSortParameters = 0;
    LastIndexSortParameters = 0;
}

class ChangingParameters {
    /**
     * sortParameters: Map 
     */
    mapSortParameters = new Map();
    addingSortParameterDataType;
    addingSortParameterValue;
    addingSortParameterKey;
}


function load() {
    CreatsSortParametersInLink(FullDuty);
    CreatsSortParametersInLink(Cut);
}

BrandType.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
});

DriveType.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
});

GearboxType.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
});

FullDuty.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
});

Cut.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
});

PriceFrom.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
    if (Number(event.target.value) > Number(PriceTo.value)) {
        event.target.value = MinPrice;
        PriceTo.value = MaxPrice;
    }
});

PriceTo.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
    if (Number(event.target.value) < Number(PriceFrom.value)) {
        PriceFrom.value = MinPrice;
        event.target.value = MaxPrice;
    }
});

StatusCar0.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
    if (URLOk) {
        document.location.href = submitLink.attributes['href'].value;
    }
});

StatusCar1.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
    if (URLOk) {
        document.location.href = submitLink.attributes['href'].value;
    }
});

StatusCar2.addEventListener("change", (event) => {
    CreatsSortParametersInLink(event.target);
    if (URLOk) {
        document.location.href = submitLink.attributes['href'].value;
    }
});

/**
 * 
 * @param {*} target 
 * @returns 
 */
function CreatsSortParametersInLink(target) {
    URLOk = true;

    let linkHref = submitLink.attributes["href"].value

    linkHref = decodeURIComponent(linkHref);

    linkHref = CheckExistenceStartValueOfSortParameters(linkHref);

    let indexesSortParameters = InitPositionSortParametersInLink(linkHref);

    let oldSortParameters = cutSortParametersFromLink(linkHref, indexesSortParameters);

    let mapSortParameters = splitSortParameters(oldSortParameters);

    let newSortParameters = changingMapSortParameters(createChangingParameters(mapSortParameters, target));

    if (newSortParameters == "") {
        linkHref = linkHref.Insert(indexesSortParameters.StartIndexSortParameters, indexesSortParameters.LastIndexSortParameters, "")
            .replace(startValueOfSortParameters + '/', "");

        submitLink.attributes["href"].value = linkHref;
        return;
    }

    linkHref = linkHref.Insert(indexesSortParameters.StartIndexSortParameters,
        indexesSortParameters.StartIndexSortParameters + oldSortParameters.length, newSortParameters);

    submitLink.attributes["href"].value = linkHref;
}

/**
 * 
 * @param {Map} mapSortParameters 
 * @param {*} target 
 * @returns {ChangingParameters}
 */
function createChangingParameters(mapSortParameters, target) {
    let changingParameters = new ChangingParameters();

    changingParameters.mapSortParameters = mapSortParameters;
    changingParameters.addingSortParameterKey = target.attributes["data-sortParameterName"].value;

    changingParameters.addingSortParameterDataType = '';

    if (target.attributes["data-sortParameterDataType"] != undefined) {
        changingParameters.addingSortParameterDataType = target.attributes["data-sortParameterDataType"].value.toLowerCase();
    }

    if (target.type == "checkbox") {
        changingParameters.addingSortParameterValue = target.checked.toString();
    }
    else {
        changingParameters.addingSortParameterValue = target.value.replaceAll(" ", "-");
    }


    return changingParameters;
}

/**
 * @param {string} sortParameters 
 * @returns {Map} 
 */
function splitSortParameters(sortParameters) {
    let mapSortParameters = new Map();
    let splitedSortParameters = sortParameters.split(/[;=]/);

    if (splitedSortParameters == '') {
        return mapSortParameters;
    }

    if (splitedSortParameters.indexOf("") != -1 || splitedSortParameters.length % 2 == 1) {
        URLOk = false;
        return mapSortParameters;
    }

    for (let i = 0; i < splitedSortParameters.length; i++) {
        mapSortParameters.set(splitedSortParameters[i], splitedSortParameters[++i]);
    }

    return mapSortParameters;
}

/**
 * @param {string} value 
 */
function InitPositionSortParametersInLink(value) {
    let indexesSortParameters = new IndexesSortParameters();
    indexesSortParameters.StartIndexSortParameters = value.indexOf(startValueOfSortParameters) + startValueOfSortParameters.length;
    indexesSortParameters.LastIndexSortParameters = value.indexOf("/", indexesSortParameters.StartIndexSortParameters);
    return indexesSortParameters;
}

/**
 * if start value of sort parameters is not existence function will return with this 
 * @param {string} value 
 */
function CheckExistenceStartValueOfSortParameters(value) {
    let newValue = value;
    if (newValue.indexOf(startValueOfSortParameters) == -1) {
        newValue = checkSlashInEnd(newValue);
        return newValue += startValueOfSortParameters + "/";
    }
    return newValue = checkSlashInEnd(newValue);
}

/**
 * 
 * @param {ChangingParameters} changingParameters 
 * @returns {string} New sort parameters 
 */
function changingMapSortParameters(changingParameters) {
    let strSortParameters;
    if (changingParameters.addingSortParameterValue.search(/[\p{Alpha}|\d]/iu) == -1) {
        changingParameters.mapSortParameters.delete(changingParameters.addingSortParameterKey);
        return assembleMapToStr(changingParameters.mapSortParameters);
    }

    changingParameters.addingSortParameterValue = changeRangeParameterInMap(changingParameters);

    return assembleMapToStr(changingParameters.mapSortParameters.set(changingParameters.addingSortParameterKey, changingParameters.addingSortParameterValue));
}

/**
 * when addingSortParameterValue is range-to or range-from it changes parameter as will be specified in the addingSortParameterValue  
 * @param {ChangingParameters} changingParameters 
 * @returns {string} new addingSortParameterValue
 */
function changeRangeParameterInMap(changingParameters) {
    if (changingParameters.addingSortParameterDataType == '' || (changingParameters.addingSortParameterDataType.toLowerCase() != "range-from" && changingParameters.addingSortParameterDataType.toLowerCase() != "range-to")) {
        return changingParameters.addingSortParameterValue;
    }

    let range = []; // Array

    if (changingParameters.mapSortParameters.has(changingParameters.addingSortParameterKey)) {
        range = changingParameters.mapSortParameters.get(changingParameters.addingSortParameterKey).split('-');
    }
    else {
        range = [MinPrice, MaxPrice];
    }

    if ((changingParameters.addingSortParameterDataType == "range-from" && Number(changingParameters.addingSortParameterValue) > range[To])
        || (changingParameters.addingSortParameterDataType == "range-to" && Number(changingParameters.addingSortParameterValue) < range[From])) {
        return MinPrice + "-" + MaxPrice;
    }

    if (changingParameters.addingSortParameterDataType == "range-from") {
        range[From] = Number(changingParameters.addingSortParameterValue);
    }
    else if (changingParameters.addingSortParameterDataType == "range-to") {
        range[To] = Number(changingParameters.addingSortParameterValue);
    }

    return range.join('-');
}

/**
 * @param {Map} map 
 */
function assembleMapToStr(map) {
    let str = "";

    for (let [key, value] of map) {
        str += key + "=" + value + ";";
    }

    return str.slice(0, str.length - 1);
}

function cutSortParametersFromLink(value, indexesSortParameters) {
    return value.substring(indexesSortParameters.StartIndexSortParameters, indexesSortParameters.LastIndexSortParameters);
}

//if Slash is missing function adds Slash 
function checkSlashInEnd(value) {
    if (value[value.length - 1] != '/') {
        return value += "/";
    }
    return value;
}

String.prototype.Insert = function Insert(startIndex, endIndex, sudstring) {
    return this.slice(0, startIndex) + sudstring + this.slice(endIndex);
}

load();

