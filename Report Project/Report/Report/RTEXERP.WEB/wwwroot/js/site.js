// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

     /// =====  1
    //var url = window.location;
    ////for sidebar menu but not for treeview submenu
    //$('ul.sidebar-menu a').filter(function () {
    //    return this.href == url;
    //}).parent().siblings().removeClass('active').end().addClass('active');
    ////for treeview which is like a submenu
    //$('ul.treeview-menu a').filter(function () {
    //    return this.href == url;
    //}).parentsUntil(".sidebar-menu > .treeview-menu").siblings().removeClass('active menu-open').end().addClass('active menu-open');


    //======  2
    //var url = window.location.href;
    //// for sidebar menu entirely but not cover treeview
    //$('ul.sidebar-menu a').filter(function () {
    //    return this.href == url;
    //}).parent().addClass('active');
    //// for treeview
    //$('ul.treeview-menu a').filter(function () {
    //    return this.href == url;
    //}).closest('.treeview').addClass('active');

    //  ------ 3
    /*
    var url = window.location;
    // for sidebar menu entirely but not cover treeview
    $('ul.sidebar-menu a').filter(function () {
        return this.href != url;
    }).parent().removeClass('active');

    // for sidebar menu entirely but not cover treeview
    $('ul.sidebar-menu a').filter(function () {
        return this.href == url;
    }).parent().addClass('active');

    // for treeview
    $('ul.treeview-menu a').filter(function () {
        return this.href == url;
    }).parentsUntil(".sidebar-menu > .treeview-menu").addClass('active');   
    */

    // 4
    //var url = window.location;
    //// for sidebar menu entirely but not cover treeview
    //$('ul.sidebar-menu a').filter(function () {
    //    return this.href != url;
    //}).parent().removeClass('active');

    //// for sidebar menu entirely but not cover treeview
    //$('ul.sidebar-menu a').filter(function () {
    //    return this.href == url;
    //}).parent().addClass('active');

    //// for treeview
    //$('ul.treeview-menu a').filter(function () {
    //    return this.href == url;
    //}).parentsUntil(".sidebar-menu > .treeview-menu").addClass('active');

    /// 5
    /** add active class and stay opened when selected */
    //var url = window.location;

    //// for sidebar menu entirely but not cover treeview
    //$('ul.sidebar-menu a').filter(function () {
    //    return this.href == url;
    //}).parent().addClass('active');
    ////Top bar
    //$('ul.navbar-nav a').filter(function () {
    //    return this.href == url;
    //}).parent().addClass('active');

    //// for treeview
    //$('ul.treeview-menu a').filter(function () {
    //    return this.href == url;
    //}).parentsUntil(".sidebar-menu > .treeview-menu").addClass('active');

    //6
    /*
    var url = window.location;
    // for sidebar menu but not for treeview submenu
    $('ul.sidebar-menu a').filter(function () {
        return this.href == url;
    }).parent().siblings().removeClass('active').end().addClass('active');
    // for treeview which is like a submenu
    
    $('ul.treeview-menu a').filter(function () {
        return this.href == url;
    }).parentsUntil(".sidebar-menu > .treeview-menu").siblings().removeClass('active menu-open').end().addClass('active menu-open');
    
    $('ul.treeview-menu a').filter(function () { return this.href == url; })
        .parentsUntil(".sidebar-menu > .treeview-menu")
        .siblings().removeClass('active menu-open').end()
        .addClass('active menu-open');

    */
    ///7
    /** add active class and stay opened when selected */
    var url = window.location;

    // for sidebar menu entirely but not cover treeview
    $('ul.sidebar-menu a').filter(function () {
        return this.href == url;
    }).parent().addClass('active');

    // for treeview
    $('ul.treeview-menu a').filter(function () {
        return this.href == url;
    }).parentsUntil(".sidebar-menu > .treeview-menu").addClass('active');
});

 