"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DepartmentService = void 0;
var rxjs_1 = require("rxjs");
var DepartmentService = /** @class */ (function () {
    function DepartmentService(httpClient) {
        this.httpClient = httpClient;
        this.departmentsSubject = new rxjs_1.BehaviorSubject([]);
    }
    DepartmentService.prototype.getAll = function () {
        this._getAll();
        return this.departmentsSubject.asObservable();
    };
    DepartmentService.prototype.create = function (department) {
        return this._create(department);
    };
    DepartmentService.prototype.update = function (department) {
        return this._update(department);
    };
    DepartmentService.prototype.getById = function (id) {
        return this._getById(id);
    };
    DepartmentService.prototype._getAll = function () {
        var _this = this;
        debugger;
        return this.httpClient.get("api/Department/GetAll")
            .subscribe(function (departments) { return _this.departmentsSubject.next(departments); }, function (error) { return _this.departmentsSubject.error(error); });
    };
    DepartmentService.prototype._create = function (department) {
        debugger;
        return this.httpClient.post('api/Department/Add', department);
    };
    DepartmentService.prototype._update = function (department) {
        return this.httpClient.post('api/Department/Update', department);
    };
    DepartmentService.prototype._getById = function (id) {
        return this.httpClient.get("api/Department/GetById/" + id);
    };
    DepartmentService.prototype.delete = function (department) {
        return this.httpClient.post('api/Department/Delete', department);
    };
    return DepartmentService;
}());
exports.DepartmentService = DepartmentService;
//# sourceMappingURL=department.service.js.map