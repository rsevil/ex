var Views;
(function (Views) {
    var Home;
    (function (Home) {
        var Index = (function () {
            function Index() {
                var _this = this;
                $('#btnClear').click(function (e) { return _this.onBtnClearClick(e); });
            }
            Index.prototype.onBtnClearClick = function (e) {
                $('[name=CreditCardNumber]').val('');
            };
            return Index;
        }());
        Home.Index = Index;
    })(Home = Views.Home || (Views.Home = {}));
})(Views || (Views = {}));
//# sourceMappingURL=Index.js.map