
var imageFolder = 'images';

function SpecialPopupClose(refreshOnClose) {
    $("#spdiv").remove();

    if (refreshOnClose == 1) {
        location.reload();
    }
}

//  page - page name
//  width/height - desired size to the new window
//  refreshOnClose - (1 - yes, 0 - no) if window will refresh when closing the popup
function SpecialPopup(page, width, height, refreshOnClose) {
    var _html = '<div id="spdiv" >';

    var temp = new Array();
    var path = '';
    temp = window.location.pathname.toString().split('/');
    if (temp.length > 1) {
        for (var i = 0; i < temp.length-1; i++) {
            path += '../';
        }
    }

    _html += '<div id="contentxpto" style="width: ' + width + 'px; height:' + (height + (30 + 10)) + 'px;">';
    _html += '<div style="background-color:#999999; width:' + width + 'px; height:30px; margin:0 0 10px 0;">';
    _html += '<div style=" float:right; margin:4px; background-color:#f1f1f1; cursor:pointer;" onclick="SpecialPopupClose(' + refreshOnClose + ');"><img alt="" title="fechar" src="' + path + imageFolder + '/icones/btClose.png"/></div>';
    _html += '</div>';
    _html += '<iframe frameborder="0" src="' + page + '" width="' + width + '" height="' + height + '"></iframe>';

    _html += '</div></div>';

    $("body").append(_html);

    $("#spdiv").css({
        'position': 'fixed',
        'top': '0px',
        'left': '0px',
        'padding': '0px',
        'width': '100%',
        'color': '#333',
        'height': '100%',
        'background-image': 'url("' + path + imageFolder + '/specpopupbg.png")',
        'z-index': '100'
    });

    $("#contentxpto").css({
        'position': 'absolute',
        'left': '50%',
        'margin-left': '-' + (width / 2) + 'px',
        'top': '30px',
        'font-weight': 'bold',
        'z-index': '101',
        'background': '#f1f1f1',
        'border': '1px solid #666666'
    });
}

