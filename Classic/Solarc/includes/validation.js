function validateField(field, alerttxt) {
    with (field) {
        if (value == null || value == "") {
            alert('Campo em falta: '+alerttxt);
            return false;
        }
        else
            return true;
    }
}