// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function do_resize(textbox) {

    var maxrows = 15;
    var txt = textbox.value;
    var cols = textbox.cols;

    var arraytxt = txt.split('\n');
    var rows = arraytxt.length;

    for (i = 0; i < arraytxt.length; i++)
        rows += parseInt(arraytxt[i].length / cols);

    if (rows > maxrows) textbox.rows = maxrows;
    else textbox.rows = rows;
}