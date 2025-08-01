function checkNumeric(event) {
    var key = window.event ? event.keyCode : event.which;
    if (event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 46
        || event.keyCode == 37 || event.keyCode == 39) {
        return true;
    }
    if (event.which === 13) {
        $.next().focus();
    }
    else if (key < 48 || key > 57) {
        return false;
    }
    else return true;
}

function checkDecimal(event) {
    
    var key = window.event ? event.keyCode : event.which;//|| event.keyCode == 46
    if (event.keyCode == 8 || event.keyCode == 9
        || event.keyCode == 37 || event.keyCode == 39) {
        return true;
    }
    if (event.which === 13) {
        $(this).next().focus();
    }
    else if (key == 46) {
        var element = event.target.id;
        var findDecimal = $('#' + element).val();
        var isExist = ".";
        if (findDecimal.indexOf(isExist) != -1) {
            return false;
        } else {
            return true;
        }

    }
    else if (key != 46 && (key < 48 || key > 57)) {
        return false;
    }
    else return true;
}

function ValidateEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
        return (true);
    } else {
        return (false);
    }
}

function RtnNumber(num) {
    return parseInt(num) || 0;
}
function RtnFloat(value) {
    value = value == undefined ? 0 : value;
    value = value == "" ? 0 : value;
    return parseFloat(value);
}
function RtnFloatUpToPrecision(value, precision) {
   
    if (precision == "") {
        precision = 2;
    }

    value = RtnFloat(value).toFixed(precision);

    return parseFloat(value);
}


function ValidateInput(InputType, field) {
    debugger;
    var sKey = String.fromCharCode(window.event.keyCode)
    if (InputType == "alpha") {
        if (!((window.event.keyCode >= 65 && window.event.keyCode <= 90) || (window.event.keyCode >= 97 && window.event.keyCode <= 122) || (window.event.keyCode == 32))) {
            window.event.returnValue = false
        }
    }
    else if (InputType == "alphanumeric") {
        if (!((window.event.keyCode >= 64 && window.event.keyCode <= 90) || (window.event.keyCode >= 97 && window.event.keyCode <= 122) || (window.event.keyCode == 32) || (window.event.keyCode >= 48 && window.event.keyCode <= 57) || (window.event.keyCode >= 44 && window.event.keyCode <= 47) || (window.event.keyCode == 37))) {
            window.event.returnValue = false
        }
    } else if (InputType == "numericdec") {
        if (!((window.event.keyCode >= 48 && window.event.keyCode <= 57) || (window.event.keyCode == 46))) {
            window.event.returnValue = false
        }
        else if (isNaN(window.event.srcElement.value + '' + sKey))
            window.event.returnValue = false
    } else if (InputType == "numeric") {
        if (!((window.event.keyCode >= 48 && window.event.keyCode <= 57))) {
            window.event.returnValue = false
        }

    } else if (InputType == "none") {
        window.event.returnValue = false
    }
}

function numericsOnly() {

    var kCode = window.event.keyCode;
    var value = window.event.srcElement.value;
    var isDecimal = true;

    if (value.indexOf(".") == -1)
        isDecimal = false;

    if (isDecimal) {
        if ((kCode >= 48 && kCode <= 57) || (kCode >= 96 && kCode <= 105) || (kCode >= 37 && kCode <= 40) || kCode == 46 || kCode == 8 || kCode == 9 || kCode == 13) { }
        else
            window.event.returnValue = false;
    }

    if ((kCode >= 48 && kCode <= 57) || (kCode >= 96 && kCode <= 105) || (kCode >= 37 && kCode <= 40) || kCode == 110 || kCode == 190 || kCode == 46 || kCode == 8 || kCode == 9 || kCode == 13) { }
    else
        window.event.returnValue = false;
}

function percentage() {

    var kCode = window.event.keyCode;
    var value = window.event.srcElement.value;
    var isDecimal = true;

    if (value.indexOf(".") == -1)
        isDecimal = false;

    if (kCode == 8 || kCode == 9 || kCode == 13) {
        return true;
    }

    if (isDecimal) {
        if ((kCode >= 48 && kCode <= 57) || (kCode >= 96 && kCode <= 105) || (kCode >= 37 && kCode <= 40) || kCode == 46) {
            //if (parseFloat(value) >= 100) {
            //    window.event.returnValue = false;
            //    var id = window.event.srcElement.id;
            //    $("#" + id).val(0);
            //}
        }
        else
            window.event.returnValue = false;
    }

    if ((kCode >= 48 && kCode <= 57) || (kCode >= 96 && kCode <= 105) || (kCode >= 37 && kCode <= 40) || kCode == 110 || kCode == 190 || kCode == 46) {
        //if (parseFloat(value) >= 100) {
        //    window.event.returnValue = false;
        //    var id = window.event.srcElement.id;
        //    $("#" + id).val(0);
        //}
    }
    else
        window.event.returnValue = false;

}
function getValue(elem) {
    let returnValue = 0;
    //let _value = $(elem).filter(function () { return $(this).val(); });
    //if (_value.length.length>0) {
    //    returnValue = _value;
    //}
    let value = $(elem).val();
    if (value.length > 0) {
        returnValue = value;
    }  
    return returnValue;
}

//function getLocationCode(location) {
//    let CompanyCode = "CF"
//    if (companyId == 183) {
//        CompanyCode = "RT";
//    }
//    return CompanyCode;
//}