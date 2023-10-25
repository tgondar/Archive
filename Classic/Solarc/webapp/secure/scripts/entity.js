
function newEntityForm() {
    var html;
    html += '<div id="backform" style="display:none;">';
    html += '<div id="backformContent">';
    html += '<label for="txtEntity2">';
    html += 'Codigo';
    html += '</label><br />';
    html += '<input id="txtCode" />';
    html += '<br />';

    html += '<label for="txtCode2">';
    html += 'Codigo';
    html += '</label><br />';
    html += '<input id="txtCode2" />';
    html += '<br />';

    html += '<label for="txtReference2">';
    html += 'Referencia';
    html += '</label><br />';
    html += '<input id="txtReference2" />';
    html += '<br />';

    html += '<label for="txtObservation">';
    html += 'Observação';
    html += '</label><br />';
    html += '<input id="txtObservation" />';
    html += '<br />';

    html += '<label for="txtLocalization">';
    html += 'Localização';
    html += '</label><br />';
    html += '<input id="txtLocalization" />';
    html += '<br /><br /><br />';

    html += '<input type="button" value="Adicionar" onclick="AddProcessG()" />';
    html += '<input type="button" value="cancelar" onclick="CloseForm()" />';

    html += '</div>';
    html += '</div>';



    $("#backform").css({
        'display': 'block',
        'position': 'fixed',
        'top': '0px',
        'left': '0px',
        'padding': '0px',
        'width': '100%',
        'color': '#333',
        'height': '100%',
        'background-image': 'url("../../images/specpopupbg.png")',
        'z-index': '100'
    });
    $("#backformContent").css({
        'position': 'absolute',
        'padding': '10px',
        'width': '400px',
        'left': '50%',
        'margin-left': '-200px',
        'top': '30px',
        'font-weight': 'bold',
        'z-index': '101',
        'background': '#f1f1f1',
        'border': '1px solid #666666'
    });
}
