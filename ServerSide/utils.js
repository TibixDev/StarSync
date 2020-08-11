function showFileModified() {
    var input, file;

    if (typeof window.FileReader !== 'function' &&
        typeof window.FileReader !== 'object') {
        alert("The file API isn't supported on this browser yet.");
        return;
    }

    input = document.getElementById('customFile');
    if (!input) {
        alert("Failed to find customFile element. ");
    }
    else if (!input.files) {
        alert("This browser doesn't seem to support the `files` property of file inputs.");
    }
    else if (!input.files[0]) {
        alert("Please select a file before clicking this button.");
    }
    else {
        file = input.files[0];
        var modifiedDate = new Date(file.lastModified).toISOString().slice(0, 19).replace('T', ' ');
        //document.getElementById("dateModified").value = modifiedDate.toLocaleString('en-GB', { timeZone: 'UTC' });
        document.getElementById("dateModified").value = modifiedDate;
    }
}

function retrieveProgress()
{
     location.href = "retrieve.php";
} 

function showUploadDate()
{
    var now = new Date().toISOString().slice(0, 19).replace('T', ' ');
    //console.log(Intl.DateTimeFormat().resolvedOptions().timeZone);
    document.getElementById("uploadDate").value = now;
}