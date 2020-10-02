/*This Javascript is constructed in the manner it is becasue i was habing a hard time with MSIX in Admin rights*/

//These variables call from c# thhe path for the assets getroot 
var localpath = new String(window.external.getdir());
var getroot = new String(window.external.getroot());


var settingsbtn = document.getElementById("settingsbtn");
var closebtn = document.getElementById("closedbtn");
var infolink = document.getElementById("infolink");

if (localpath == "/") {

    localpath = "";
}
if (localpath == "/") {

    localpath = "";
}
/*This function populates the images in the html*/
function imges() {

    var imgs = document.querySelectorAll(".imgresourcea");

    
    imgs[0].src = getroot + "assets/BoostBtn/BtnPress.gif";
    imgs[1].src = getroot + "assets/BoostBtn/Move.gif";
    imgs[2].src = getroot + "assets/BoostBtn/TrayMode.gif";
    imgs[3].src = getroot + "assets/BoostBtn/Settings.gif";
    imgs[4].src = getroot + "assets/BoostBtn/TrayBtnAction.gif";

}
//href = "https://www.maketecheasier.com/ultimate-performance-feature-windows10/"
imges();


function settingsaction(val) {
    var settingspressed = new Boolean(window.external.getsettingspressed());

    if (settingspressed) {
        window.external.setsettingspressed(true);
    } else {
        window.external.setsettingspressed(true);
    }
}
function closebtnaction(val) {
    var closepressed = new Boolean(window.external.getclosedpressed());

    if (closepressed) {
        window.external.setclosedpressed(true);
    } else {
        window.external.setclosedpressed(false);
    }
   
}
function helplinkaction(val) {
    
    var linkpressed = window.external.getlinkpressed();
    alert(linkpressed);
    if (!linkpressed) {
        window.external.setlinkpressed(true);
        
    } else {
        window.external.setlinkpressed(false);

    }

}


settingsbtn.addEventListener("click",settingsaction);
closebtn.addEventListener("click",closebtnaction);
infolink.addEventListener("click",helplinkaction);
