﻿$(document).ready(function () {
    var x = 0;
    var s = "";

    console.log("Hello Pluralsight");

    var theForm = $("#theForm");
    theForm.hide();

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("Buying Item");
    });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You clicked on " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popForm.slideToggle(500);
    });
});