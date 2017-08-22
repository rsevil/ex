module Views.Home {
    export class Index {
        constructor() {
            $('#btnClear').click(e => this.onBtnClearClick(e));
        }

        private onBtnClearClick(e: JQueryEventObject) {
            $('[name=CreditCardNumber]').val('');
        }
    }
}