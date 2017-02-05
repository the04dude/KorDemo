var priceFormatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'CAD',
    minimumFractionDigits: 2
});

function priceCellRenderer(params) {
    return priceFormatter.format(params.value);
}

var numberFormatter = new Intl.NumberFormat('en-US', {
    style: 'decimal',
    minimumFractionDigits: 0
});

function numberCellRenderer(params) {
    return numberFormatter.format(params.value);
}

var columnDefs = [
    { headerName: "Make", field: "make", width: 150 },
    { headerName: "Model", field: "model", width: 150 },
    {
        headerName: "Price", field: "price", width: 150, filter: 'number', cellRenderer: priceCellRenderer,
    },
    { headerName: "Mileage", field: "mileage", width: 150, filter: 'number', cellRenderer: numberCellRenderer },
];

var gridOptions = {
    columnDefs: columnDefs,
    rowData: null,
    enableFilter: true
};

function onFilterChanged(value) {
    gridOptions.api.setQuickFilter(value);
}

// setup the grid after the page has finished loading
document.addEventListener('DOMContentLoaded', function () {
    var gridDiv = document.querySelector('#myGrid');
    new agGrid.Grid(gridDiv, gridOptions);

    // do http request to get our sample data - not using any framework to keep the example self contained.
    // you will probably use a framework like JQuery, Angular or something else to do your HTTP calls.
    var httpRequest = new XMLHttpRequest();
    httpRequest.open('GET', '/cars');
    httpRequest.send();
    httpRequest.onreadystatechange = function () {
        if (httpRequest.readyState == 4 && httpRequest.status == 200) {
            var httpResult = JSON.parse(httpRequest.responseText);
            gridOptions.api.setRowData(httpResult.cars);
        }
    };
});