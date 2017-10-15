// https://developer.mozilla.org/en-US/docs/Web/API/Document/createDocumentFragment
// ...better performance ???

var fragment = document.createDocumentFragment();

result.forEach(function(element)
{
    var li = document.createElement("li");
    li.appendChild(document.createTextNode(element.name));
    fragment.appendChild(li);
});

list.appendChild(fragment);

// for(i = 0; i < result.length; i++)
// {
//     var li = document.createElement("li");
//     li.appendChild(document.createTextNode(result[i].name));
//     list.appendChild(li);
// }