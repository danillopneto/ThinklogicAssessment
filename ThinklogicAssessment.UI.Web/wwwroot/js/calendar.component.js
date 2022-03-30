window.calendarcomponent = {};

window.calendarcomponent = function ($el) {
    this.$el = $el;
    this.$el.data('CalendarComponent', this);
    this.selectedDate = this.$el.data('current-date');

    this.$elDay = this.$el.find('.day');
    this.$elPreviewMonthBtn = this.$el.find('#previousMonthBtn');
    this.$elNextMonthBtn = this.$el.find('#nextMonthBtn');

    this._initialize();
}

window.calendarcomponent.prototype = {
    _initialize: function () {
        this._addEvents();

        this.$el.trigger('onLoad', this.selectedDate);
    },

    _addEvents: function () {
        var _this = this;

        _this.$elDay.on('click', function (event) {
            _this._dayClicked(event.currentTarget);
        });

        _this.$elPreviewMonthBtn.on('click', function () {
            _this.$el.trigger('onPreviousMonthClicked', _this.selectedDate);
        });
        _this.$elNextMonthBtn.on('click', function () {
            _this.$el.trigger('onNextMonthClicked', _this.selectedDate);
        });
    },

    _dayClicked: function (target) {
        var _this = this;

        $('.day').removeClass('selectedDay');
        $(target).addClass('selectedDay');

        _this.selectedDate = $(target).data('current-date');
        _this.$el.data('current-date', _this.selectedDate);
        _this.$el.trigger('onDateSelected', _this.selectedDate);
    }
}