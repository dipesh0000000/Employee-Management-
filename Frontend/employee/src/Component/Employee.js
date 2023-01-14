import EmployeeQualification from "./EmployeeQualification";
function Employee(){
    return (
       <div className="container" style={{paddingTop: "30px"}} >
        <div className="row">
        <div className="col-md-3">
            <p>Demo</p>
        </div>
        <div className="col-md-9">
        <div className="form-group">
            <label htmlFor="employeeName">Employee name</label>
            <input type="text" className="form-control" id="employeeName" placeholder="Enter employee name" />
        </div>
        <div className="form-group">
            <label htmlFor="Address">Address</label>
            <input type="text" className="form-control" id="Address" placeholder="Address" />
        </div>
        <div className="form-group">
            <label htmlFor="Salary">Salary</label>
            <input type="text" className="form-control" id="Salary" placeholder="Salary" />
        </div>
        <div>
            <EmployeeQualification />
        </div>
        <button type="submit" className="btn btn-primary">Submit</button>
        </div>
        </div>
       
        
       </div>
    );
}
export default Employee;
