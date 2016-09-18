function ismaxlength(objTxtCtrlh, objLblCtrlh, maxlength) {
    var lbl = $(objLblCtrlh);
    if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > maxlength)
        objTxtCtrl.value = objTxtCtrl.value.substring(0, maxlength);
    if (document.all)
    if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > maxlength)
        lbl.html(objTxtCtrl.value.length + " de " + maxlength);
        //document.getElementById(objlblCtrl.id).innerText = objTxtCtrl.value.length + " de " + maxlength;
    else
        lbl.html(objTxtCtrl.value.length + " de " + maxlength);
        //document.getElementById(objlblCtrl.id).textContent = objTxtCtrl.value.length + " de " + maxlength;
}

function ismaxlength1(objTxtCtrlh, objLblCtrlh, maxlength) {
    var obj = $(objTxtCtrlh);
    var lbl = $(objLblCtrlh);
    maxlengthint = parseInt(maxlength);
    textoActual = obj.val();
    currentCharacters = obj.val().length;
    remainingCharacters = maxlengthint - currentCharacters;
    // Detectamos si es IE9 y si hemos llegado al final, convertir el -1 en 0 - bug ie9 porq. no coge directamente el atributo 'maxlength' de HTML5
    if (document.addEventListener && !window.requestAnimationFrame) {
        if (remainingCharacters <= -1) {
            remainingCharacters = 0;
        }
    }
    //lbl.value = remainingCharacters;
    
    if (!!maxlength) {
        var texto = obj.val();
        if (texto.length >= maxlength) {
            obj.val(texto.substring(0, maxlength));
            //e.preventDefault();
        }
        else if (texto.length < maxlength) {
        }
    }
    lbl.html(obj.val().length + " de " + maxlength);
}