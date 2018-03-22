

// In ListView.aspx: sort products by price/popularity(asc/desc)
// Sort elements by attribute numerical value  with DropDownList #DDLSortProducts

var $container;
var container, child, element, attribute, ascending;

//Save container elements order before sorting
var defaultOrder = $.makeArray($(".product"));

function SortProducts() {

    var sortingMethod = $('#DDLSortProducts').val();
    $container = $('#products');

    if (sortingMethod === '0') {
        $container.append(defaultOrder);
    }

    container = 'div#products';
    child = 'div.product';

    //Sort by Popularity
    element = 'div.popular';
    attribute = 'data-popular';

    //Filter null element attributes from page
    var tempArray = $.makeArray($(child));
    var nullElement = tempArray.filter(elem => $(elem).find(element).attr(attribute) === "0");
    tempArray = tempArray.concat(tempArray.splice(0, nullElement.length, nullElement));

    //SortByAttrNumericalValue products & if element attribute === 0, move nullElement end of the page
    if (sortingMethod === '1') {
        SortByAttrNumericalValue(container, child, element, attribute);
        $container.append(nullElement);

    }

    //SortByAttrNumericalValue products & if element attribute === 0, move nullElement beginning of the page
    if (sortingMethod === '2') {
        ascending = false;
        SortByAttrNumericalValue(container, child, element, attribute, ascending);
        $container.prepend(nullElement);
    }

    //Sort by price
    element = 'span.price';
    attribute = 'data-price';

    //SortByAttrNumericalValue products & if element attribute === 0, move nullElement end of the page
    if (sortingMethod === '3') {
        ascending = false;
        SortByAttrNumericalValue(container, child, element, attribute, ascending);
        $container.append(nullElement);
    }

    //SortByAttrNumericalValue products & if element attribute === 0, move nullElement beginning of the page
    if (sortingMethod === '4') {
        SortByAttrNumericalValue(container, child, element, attribute);
        $container.prepend(nullElement);
    }
}

$(window).on('load', function () {
    SortProducts();
});