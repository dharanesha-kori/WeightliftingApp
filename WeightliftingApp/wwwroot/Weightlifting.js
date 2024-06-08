window.downloadFile = function (fileContent, fileName) {
    var blob = new Blob([fileContent], { type: "application/octet-stream" });
    var link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};

window.showAlert = function (message) { 
    //alertify.alert(message);
    Swal.fire({
        title: "American Weight Lifting Service",
        text: message,
        icon: "success"
    });
};
window.showError = function (message) {
    //alertify.alert(message);
    Swal.fire({
        title: "American Weight Lifting Service",
        text: message,
        icon: "error"
    });
};

//window.showConfirm = function (message, callback) {
//    alertify.confirm(message, function (e) {
//        callback(e);
//    });
//};

//window.showPrompt = function (message, callback, defaultValue) {
//    alertify.prompt(message, function (e, str) {
//        callback(e, str);
//    }, defaultValue);
//};
