window.abrirPDF = function (pdfBase64) {
    var binaryData = atob(pdfBase64);
    var array = new Uint8Array(binaryData.length);

    for (var i = 0; i < binaryData.length; i++) {
        array[i] = binaryData.charCodeAt(i);
    }

    var blob = new Blob([array], { type: 'application/pdf' });
    var url = URL.createObjectURL(blob);

    // Crea un objeto de visor de PDF (puedes ajustar el tamaño según sea necesario)
    var pdfViewer = document.createElement('iframe');
    pdfViewer.style.width = '100%';
    pdfViewer.style.height = '100%';
    pdfViewer.style.display = 'none';
    pdfViewer.src = url;

    // Agrega el visor de PDF al cuerpo del documento
    document.body.appendChild(pdfViewer);

    // Enfoca el visor de PDF y simula la acción de imprimir (Ctrl + P)
    pdfViewer.focus();
    pdfViewer.contentWindow.print();
};