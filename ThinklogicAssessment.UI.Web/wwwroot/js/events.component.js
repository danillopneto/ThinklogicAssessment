window.eventscomponent = {};

window.eventscomponent = function ($el) {
    this.$el = $el;
    this.$el.data('EventsComponent', this);

    this.$elEditEventBtn = this.$el.find('.editEventBtn');

    this._initialize();
}

window.eventscomponent.prototype = {
    _initialize: function () {
        this._addEvents();

        this.$el.trigger('onLoad');
    },

    _addEvents: function () {
        var _this = this;

        _this.$elEditEventBtn.on('click', function(e) {            
            _this._eventEdited(e.currentTarget);
        });
    },

    _eventEdited: function (target) {
        var data = target.parentElement.parentElement.dataset.eventdata;
        var eventData = JSON.parse(data);
        this.$el.trigger('onEventEditted', eventData);
    }
}