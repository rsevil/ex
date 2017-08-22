module Views.Home {
    export class Pin {
        constructor() {
            $('#btnClear').click(e => this.onBtnClearClick(e));
        }

        private onBtnClearClick(e: JQueryEventObject) {
            $('[name=PinNumber]').val('');
        }
    }
}