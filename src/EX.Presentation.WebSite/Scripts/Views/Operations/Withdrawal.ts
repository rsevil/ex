module Views.Operations {
    export class Withdrawal {
        constructor() {
            $('#btnClear').click(e => this.onBtnClearClick(e));
        }

        private onBtnClearClick(e: JQueryEventObject) {
            $('[name=Amount]').val('');
        }
    }
}