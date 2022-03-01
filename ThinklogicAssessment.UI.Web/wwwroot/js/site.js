window.calendar = function ($el, model) {
    this.$el = $el;
    this.$el.data('Calendar', this);
    this.model = model;

    this.$elId = this.$el.find('[name="Id"]');
    this.$elTitle = this.$el.find('[name="Title"]');
    this.$elStartDate = this.$el.find('[name="StartDate"]');
    this.$elEndDate = this.$el.find('[name="EndDate"]');
    this.$elLocation = this.$el.find('[name="Location"]');
    this.$elDescription = this.$el.find('[name="Description"]');
    this.$elEditEventBtn = this.$el.find('.editEventBtn');

    this._initialize();
}

window.calendar.prototype = {
    _initialize: function () {
        this._addEvents();        
    },


    _addEvents: function () {
        var _this = this;

        $(document).on('click', '.editEventBtn', function (e) {
            _this._editFired(e.currentTarget);
        });

        $(document).on('onLoad', '.calendar-component', function (e, date) {
            _this._dayClicked(date);
        })
        $(document).on('onDateSelected', '.calendar-component', function (e, date) {
            _this._dayClicked(date);
        })
        $(document).on('onPreviousMonthClicked', '.calendar-component', function (e, date) {
            _this._getCalendar(date, -1);
        })
        $(document).on('onNextMonthClicked', '.calendar-component', function (e, date) {
            _this._getCalendar(date, +1)
        })
    },

    _getCalendar: function (date, increment) {
        var _this = this;

        $.ajax({
            url: './GetCalendarAsync',
            type: 'POST',
            dataType: 'html',
            cache: false,
            data: {
                date: date,
                increment: increment
            }
        }).done(function (result) {
            _this.$el.find('.calendar-component').replaceWith(result);
        });
    },

    _dayClicked: function (date) {
        var _this = this;

        $.ajax({
            url: './GetEventsByDayAsync',
            type: 'GET',
            dataType: 'html',
            cache: false,
            data: {
                date: date
            }
        }).done(function (result) {
            _this.$el.find('.events-table').replaceWith(result);
        });
    },

    _editFired: function (target) {
        var _this = this;

        var data = target.parentElement.parentElement.dataset.eventdata;
        var eventData = JSON.parse(data);
        console.log(eventData);

        _this.$elId.val(eventData.Id);
        _this.$elTitle.val(eventData.Title);
        _this.$elStartDate.val(eventData.StartDate.split('T')[0]);
        _this.$elEndDate.val(eventData.EndDate.split('T')[0]);
        _this.$elLocation.val(eventData.Location);
        _this.$elDescription.val(eventData.Description);
    }
}