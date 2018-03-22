
//Js sorting methods

//Function for sorting elements inside container by numerical attribute
function SortByAttrNumericalValue(container, child, element, attribute, ascending) {

    $container = $(container);
    var sortArray = $.makeArray($container.children(child));

    sortArray.sort(function (a, b) {

        var numberA = +$(a).find(element).attr(attribute);
        var numberB = +$(b).find(element).attr(attribute);

        if (numberA > numberB) return 1;
        if (numberA < numberB) return -1;
        return 0;

    });

    if (ascending === false) {
        sortArray.reverse();
    }

    $container.empty();
    $container.append(sortArray);
}

