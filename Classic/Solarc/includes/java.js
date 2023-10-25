var newwindow = ''
function popitup(url) {
if (newwindow.location && !newwindow.closed) {
    newwindow.location.href = url;
    newwindow.focus(); }
else {
    newwindow=window.open(url,'Infiniauto','width=250,height=250,resizable=0,status=0,location=0');}
}

function _click(id)
{
    document.getElementById(id).click();
}

function YesNo() 
{
    var ans=window.confirm('Tem a certeza ?');
    if (ans==true) 
    {
        return true;
    }
    else
    {
        return false;
    }
}

function pressenter(clientid)
{
    if (window.event.keyCode == 13)
    {
        window.event.keyCode =0;
        eval("document.all."+clientid+".click()");
    }
}

//  ### check all checkboxes
function ChangeCheckBoxState(id, checkState) {
    var cb = document.getElementById(id);
    if (cb != null)
        cb.checked = checkState;
}

function ChangeAllCheckBoxStates(checkState) {
    if (CheckBoxIDs != null) {
        for (var i = 0; i < CheckBoxIDs.length; i++)
            ChangeCheckBoxState(CheckBoxIDs[i], checkState);
    }
}
//  ### check all checkboxes    -   end
