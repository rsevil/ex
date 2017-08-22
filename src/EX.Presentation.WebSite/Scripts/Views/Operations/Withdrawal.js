var Views;
(function (Views) {
    var Operations;
    (function (Operations) {
        var Withdrawal = (function () {
            function Withdrawal() {
                var _this = this;
                $('#btnClear').click(function (e) { return _this.onBtnClearClick(e); });
            }
            Withdrawal.prototype.onBtnClearClick = function (e) {
                $('[name=Amount]').val('');
            };
            return Withdrawal;
        }());
        Operations.Withdrawal = Withdrawal;
    })(Operations = Views.Operations || (Views.Operations = {}));
})(Views || (Views = {}));
//# sourceMappingURL=Withdrawal.js.map