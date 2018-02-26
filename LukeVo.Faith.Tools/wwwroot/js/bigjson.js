function loadFile() {
    var file = $("#txt-file")[0].files[0];

    if (!file) {
        alert("No file selected.");
        return;
    }

    var variableName = $("#txt-name").val();
    if (!variableName) {
        alert("Please enter variable name");
        return;
    }

    var showError = function (e) {
        $("#lbl-status").html(e);
    };

    $("#lbl-status").html("Loading...");

    var fileReader = new FileReader();
    fileReader.onload = () => {
        try {
            window[variableName] = JSON.parse(fileReader.result);
            $("#lbl-status").html("File read. Access from Developer Console: <code>window." + variableName + "</code>");
        } catch (e) {
            showError(e);
        }
        
    };

    try {
        fileReader.readAsText(file);
    } catch (e) {
        showError(e);
    }
    
}

function download() {
    var variableName = $("#txt-name").val();
    if (!variableName) {
        alert("Please enter variable name");
        return;
    }

    var obj = window[variableName];
    if (!obj) {
        alert("The variable does not exist. Make sure it is accessible from window object.");
        return;
    }

    var jsonText = JSON.stringify(obj);
    var blob = new Blob([jsonText], { type: "application/json" });
    var url = URL.createObjectURL(blob);

    var link = document.getElementById('lnk-download');
    link.href = url;
    link.download = "bigjson.json";
    link.click();

    $("#lbl-status").html("File downloaded.");
}

$(function () {
    $("#btn-load").click(loadFile);
    $("#btn-download").click(download);
});