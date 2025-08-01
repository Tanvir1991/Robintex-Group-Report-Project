//////
//controllerName= Controller name of the action
//actionName= Action/function name where to hit
//data= parameter of the action/function
//targetFieldId= Id of DDL field where to bind data
//defaultSelectedText =Default Selected Text like "Please Select"
//////
function GenerateDropDown(controllerName, actionName, data, targetFieldId, defaultSelectedText) {
  
    var ddlTargetField = $("#" + targetFieldId);
        
    $.ajax({
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        url: '/' + controllerName + '/' + actionName,
        data: data,
        dataType: 'json',
        async: false,
        success: function (data) {
            //debugger;
            ddlTargetField.html('');
            let oldGroup = "";
            let newGroup = "";
            let dropDownItem = ""
            let IsGroup = 0;
            if (defaultSelectedText !== "") {
                ddlTargetField.append('<option value="">' + defaultSelectedText + '</option>');
            }
            $.each(data, function (id, option) {
                if (IsGroup == 0 && option.Group != null) {
                    IsGroup = 1;
                    newGroup = option.Group.Name;
                    oldGroup = option.Group.Name;
                    dropDownItem += `<optgroup label="${newGroup}">`;
                }
                if (IsGroup == 1) {
                    newGroup = option.Group.Name;
                }
                if (IsGroup==1 && newGroup != oldGroup) {
                    dropDownItem += `</optgroup>`;
                    dropDownItem += `<optgroup label="${newGroup}">`;
                    oldGroup = option.Group.Name;
                }
                dropDownItem += `<option value="${option.Value}">${option.Text}</option>`;
             

            });

            if (IsGroup == 1) {
                dropDownItem += `</optgroup>`;
            }
            ddlTargetField.append(dropDownItem);
            $("#AjaxLoader").hide();
        },
        error: function (request, status, error) {
            $("#AjaxLoader").hide();
            alert(request.statusText + "/" + request.statusText + "/" + error);
        }
    });
}
function GenerateDropDownCustome(controllerName, actionName, data, targetFieldId, defaultSelectedText) {

    var ddlTargetField = $("#" + targetFieldId);

    $.ajax({
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        url: '/' + controllerName + '/' + actionName,
        data: data,
        dataType: 'json',
        async: false,
        success: function (data) {
            ddlTargetField.html(''); 
            let dropDownItem = "" 
            if (defaultSelectedText !== "") {
                ddlTargetField.append('<option value="">' + defaultSelectedText + '</option>');
            }
            $.each(data, function (id, option) {
              
                dropDownItem += `<option data-Custome1="${option.Custome1}" data-Custome2="${option.Custome2}" data-Custome3="${option.Custome3}" value="${option.Value}">${option.Text}</option>`;
                console.log(dropDownItem);
            }); 
            ddlTargetField.append(dropDownItem);
            $("#AjaxLoader").hide();
        },
        error: function (request, status, error) {
            $("#AjaxLoader").hide();
            alert(request.statusText + "/" + request.statusText + "/" + error);
        }
    });
}

function GenerateDropDownOptions(controllerName, actionName, data, defaultSelectedText) {
    var options = "";
    $.ajax({
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        url: '/' + controllerName + '/' + actionName,
        data: data,
        dataType: 'json',
        async: false,
        success: function (data) {
            //var options = "";
            var selectedItem = "";
            if (defaultSelectedText !== "") {

                options = options + '<option value="">' + defaultSelectedText + '</option>';
            }
            $.each(data, function (id, option) {
                if (option.Selected === false) {
                    selectedItem = "";
                } else {
                    selectedItem = 'selected="selected"';
                }
                options = options + '<option value="' + option.Value + '" ' + selectedItem + ' >' + option.Text + '</option>';
            });
            //  return options;
        },
        error: function (request, status, error) {
            var options = "";
            $("#AjaxLoader").hide();
            alert(request.statusText + "/" + request.statusText + "/" + error);
        }

    });
    return options;
}
function GetData(controllerName, actionName, data, defaultSelectedText) {
    var options = "";
    $.ajax({
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        url: '/' + controllerName + '/' + actionName,
        data: data,
        dataType: 'json',
        async: false,
        success: function (data) {
            options= data;
        },
        error: function (request, status, error) {
            var options = "";
            $("#AjaxLoader").hide();
            alert(request.statusText + "/" + request.statusText + "/" + error);
        }

    });
    return options;
}
//////
//targetFieldId=Id of DDL field;
//defaultSelectedText= Default text to show after clear;
//////
function ClearDropDown(targetFieldId, defaultSelectedText) {
    var ddlTargetField = $("#" + targetFieldId);
    ddlTargetField.html('');
    ddlTargetField.append('<option value="">' + defaultSelectedText + '</option>');
}


////////
//methodType= GET or POST;
//postUrl= Function URL, where to hit;
//objectVM= Object to create binded with model or view model;
//formClearFunction = Function name to clear form after save;

// c# function must return RResult type object

////////
function GenericSave(methodType, postUrl, objectVM, formClearFunction) {

    if (Object.keys(objectVM).length > 0) {
        if (methodType != "" && postUrl != "") {
            $("#AjaxLoader").show();
            $.ajax({
                type: methodType,
                data: objectVM,
                url: postUrl,
                dataType: "json",
                async: false,
                success: function (rResult) {
                    $("#AjaxLoader").hide();
                    debugger;
                    if (rResult.result == 1) {
                        if (formClearFunction != "") {
                            formClearFunction();
                        }
                        $.alert.open("success", rResult.message);
                    } else {
                        $.alert.open("error", rResult.message);
                    }

                },
                failure: function (errMsg) {
                    $("#AjaxLoader").hide();
                    $.alert.open("error", errMsg);
                }
            });
        }
    } else {

        $.alert.open("error", "Error Occured");
    }
}
function GenericSave(methodType, postUrl, objectVM, formClearFunction, buttonIdToHide) {

    if (Object.keys(objectVM).length > 0) {
        if (methodType != "" && postUrl != "") {
            $("#AjaxLoader").show();

            $.ajax({
                type: methodType,
                data: objectVM,
                url: postUrl,
                dataType: "json",
                async: false,
                beforeSend: function () {
                    $("#" + buttonIdToHide).attr("disabled", true);
                },
                success: function (rResult) {
                    $("#AjaxLoader").hide();
                    if (rResult.result == 1) {
                        if (formClearFunction != "") {
                            formClearFunction();
                        }
                        $.alert.open("Success", rResult.message);
                    } else {
                        $.alert.open("error", rResult.message);
                    }
                },
                failure: function (errMsg) {
                    $("#AjaxLoader").hide();
                    $.alert.open("error", errMsg);
                },
                complete: function () {
                    $("#AjaxLoader").hide();
                    $("#" + buttonIdToHide).removeAttr("disabled");
                }
            });
        }
    } else {
        $.alert.open("error", "Error Occured");
    }
}

//////
//Use of function GenericSave()
//gridLoadFunction= function name to load the grid
//////
function GenericSaveAndGridLoad(methodType, postUrl, objectVM, gridLoadFunction, formClearFunction) {
   
    GenericSave(methodType, postUrl, objectVM, formClearFunction);
    gridLoadFunction();    
}
function GenericSaveAndGridLoad(methodType, postUrl, objectVM, gridLoadFunction, formClearFunction, buttonIdToHide) {

    GenericSave(methodType, postUrl, objectVM, formClearFunction, buttonIdToHide);
    gridLoadFunction();
}

////////
//methodType= GET or POST;
//postUrl= Function URL, where to hit;
//objectId= Primary Key to delete the object; 

// c# function must return RResult type object

////////
function GenericDeleteWithoutConfirmation(methodType, postUrl, objectId) {
    if (parseInt(objectId) > 0) {
        if (methodType != "" && postUrl != "") {
            $.ajax({
                type: methodType,
                data: { Id: objectId },
                url: postUrl,
                dataType: "json",
                async: false,
                success: function (rResult) {
                    //debugger;
                    if (rResult.result == 1) {
                        $.alert.open("Success", rResult.message);

                    } else {
                        $.alert.open("error", rResult.message);

                    }

                },
                failure: function (errMsg) {
                    $.alert.open("error", errMsg);
                    return false;
                },
                complete: function () {
                    return true;
                }
            });
        }
    } else {
        $.alert.open("error", "Error Occured");
        return false;
    }
}

////////
//methodType= GET or POST;
//postUrl= Function URL, where to hit;
//objectId= Primary Key to delete the object; 

// c# function must return RResult type object

////////
function GenericDelete(methodType, postUrl, objectId ) {
    $.alert.open('confirm', 'Are you sure to delete this record?', function (button) {
        if (button == 'yes') {
            GenericDeleteWithoutConfirmation(methodType, postUrl, objectId);
        } else {
            return false;
        }
    });
}


//////
//Use of function GenericDelete()
//gridLoadFunction= function name to load the grid
//////
function GenericDeleteAndGridLoad(methodType, postUrl, objectId, gridLoadFunction) {
    //debugger;
    $.alert.open('confirm', 'Are you sure to delete this record?', function (button) {
        if (button == 'yes') {
            if (parseInt(objectId) > 0) {
                if (methodType != "" && postUrl != "") {
                    $.ajax({
                        type: methodType,
                        data: { Id: objectId },
                        url: postUrl,
                        dataType: "json",
                        async: false,
                        success: function (rResult) {
                            if (rResult.result == 1) {
                                $.alert.open("Success", rResult.message);
                                gridLoadFunction();
                            } else {
                                $.alert.open("error", rResult.message);
                            }
                        },
                        failure: function (errMsg) {
                            $.alert.open("error", errMsg);
                        }
                    });
                }
            } else {
                $.alert.open("error", "Error Occured");
            }
        } else {
            return false;
        }
    });
}

function DateFormat_dd_mm_yyyy(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [day,month,year].join('-');
}


function fnHtmlToExcelReport(tableID) {
    //debugger;
    var tab_text = "<table border='2px'><tr bgcolor='#87AFC6'>";
    var textRange; var j = 0;
    tab = document.getElementById(tableID); // id of table
    let reportName = $("#" + tableID).attr("data-id");
    for (j = 0; j < tab.rows.length; j++) {
        tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";
        //tab_text=tab_text+"</tr>";
    }

    tab_text = tab_text + "</table>";
    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
    tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
    {
        txtArea1.document.open("txt/html", "replace");
        txtArea1.document.write(tab_text);
        txtArea1.document.close();
        txtArea1.focus();
        sa = txtArea1.document.execCommand("SaveAs", true, reportName+".xls");
    }
    else                 //other browser not tested on IE 11
        sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));

    return (sa);
}

function Select2GroupData(data) {
    var singleObject = {
        "text": "",
        "children": [
            {
                "id": "",
                "text": ""
            }
        ]
    };

    if (data == null) {
        return {
            "text": "",
            "children": [{}]
        }
    }

    const result = data.reduce((gdata, d) => {
        if (d.Value != "") {
            const found = gdata.find(a => a.text === d.Group.Name);
            const value = { id: d.Value, text: d.Text };
            if (found) {
                found.children.push(value);
            }
            else {
                gdata.push({ text: d.Group.Name, children: [{ id: d.Value, text: d.Text }] });
            }
        }
        return gdata;
    }, []);

    return result;

}

function DropDownSelect2(method, url, paramData, targetFieldId, loader = false) {
   
    let ddlTargetField = $("#" + targetFieldId);
    ddlTargetField.html("");
    ddlTargetField.select2("destroy");

    ddlTargetField.select2({
        minimumInputLength: 0,
        ajax: {
            url: url,
            dataType: 'json',
            delay: 250,
            type: method.toUpperCase(),
            data: function (params) {
                paramData['predict'] = params.term;
                return paramData;
            },
            processResults: function (data, params) {
                return {
                    results: $.map(data, function (item) {
                        return { id: item.Value, text: item.Text };
                    })
                }
            }
        }
    })
}

function DropDownSelect2Group(method, url, paramData, targetFieldId, loader = false) {
    let ddlTargetField = $("#" + targetFieldId);
    ddlTargetField.html("");
    ddlTargetField.select2("destroy");

    ddlTargetField.select2({
        minimumInputLength: 0,
        ajax: {
            url: url,
            dataType: 'json',
            delay: 250,
            type: method.toUpperCase(),
            data: function (params) {

                paramData['predict'] = params.term;
                return paramData;
            },
            processResults: function (data, params) {
                var res = HttpRequest.Select2GroupData(data);
                return {
                    results: res
                }
            }
        }
    })
}