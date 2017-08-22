var Views;
(function (Views) {
    var Home;
    (function (Home) {
        var Pin = (function () {
            function Pin() {
                var _this = this;
                $('#btnClear').click(function (e) { return _this.onBtnClearClick(e); });
            }
            Pin.prototype.onBtnClearClick = function (e) {
                $('[name=PinNumber]').val('');
            };
            return Pin;
        }());
        Home.Pin = Pin;
    })(Home = Views.Home || (Views.Home = {}));
})(Views || (Views = {}));
//# sourceMappingURL=Pin.js.map