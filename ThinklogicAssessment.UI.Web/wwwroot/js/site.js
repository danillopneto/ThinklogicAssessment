// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.calendar = {};

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

        _this.$elEditEventBtn.on('click', function (event) {
            _this._editFired(event.currentTarget);
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