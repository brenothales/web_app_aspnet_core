
// var theForm = document.getElementById("theForm");
// theForm.hidden = true;

var theForm = $("#theForm");
theForm.hide();

// var button = document.getElementById("buyButton");
// button.addEventListener("click", function(){
//     alert("Olá Mundo!");
// });

var button = $("#buyButton");
button.on("click", function(){
    alert("Olá Mundo!");
});


// var production = document.getElementById("product-info");
var productionInfo = $(".product-props li ");
productionInfo.on("click", function(){
 console.log("You clickec on" + $(this).text());
});


var listItens = production.item[0].children;

listItens.addEventListener('hover', function(){
    alert("Esse é conteúdo!")
});