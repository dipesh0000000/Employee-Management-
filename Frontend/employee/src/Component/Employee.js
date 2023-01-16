import React, { useState } from "react";
import EmployeeQualification from "./EmployeeQualification";
import EmployeeList from './EmployeeList'

function Employee(){
    const [employeeName,setEmployeeName] = useState('');
    const [address,setAddress] = useState('');
    const [salary,setSalary] = useState(0);
    const [qualifications,setQualification] = useState([]);
    const [savingEmployee,setSavingEmployee] = useState(false);
    const [fetchEmployee, setFetchEmployee] = useState(0);

    const addEmployee = () => {
        if(validateData()){
            setSavingEmployee(true);
            const employee = {
                Name: employeeName,
                Address: address,
                Salary : parseInt(salary),
                Qualifications : qualifications 
            }
            console.log(employee)
            const requestOptions = {
                method: 'POST',
                headers: {  'Accept': 'application/json','Content-Type': 'application/json' },
                body: JSON.stringify(employee)
            };
            return fetch("https://localhost:44398/Employee",requestOptions).then((response) => response.json())
            .then((data) => 
            {
                setFetchEmployee(fetchEmployee+1);
                resetValue();
            });
        }
    }
    const resetValue = () => {
        setEmployeeName('');
        setAddress('');
        setSalary(0);
        setQualification([]);
        setSavingEmployee(false);
    };

    const validateData = () => {
        let errMsg = "";
        if(employeeName === undefined || employeeName === null || employeeName === ""){
            errMsg += "Please enter employee Name\n";    
        }
        if(address === undefined || address === null || address === ""){
            errMsg += "Please enter address\n";    
        }
        if(salary === undefined || salary === null || salary === ""){
            errMsg += "Please enter salary\n";    
        }
        if(errMsg === ""){
            return true;
        }
        else {
            alert(errMsg);
            return false;
        }
    };

    return (
       <div className="container" style={{paddingTop: "30px"}} >
        <div className="row">
        <div className="col-md-3">
            <p>Employee List</p>
            <EmployeeList trigger={fetchEmployee}/>
        </div>
        <div className="col-md-9">
        <div className="form-group">
            <label htmlFor="employeeName">Employee name</label>
            <input autoComplete="off" type="text" className="form-control" id="employeeName" placeholder="Enter employee name"
                value={employeeName}
                onChange={e => setEmployeeName(e.target.value)} />
        </div>
        <div className="form-group">
            <label htmlFor="Address">Address</label>
            <input autoComplete="off" type="text" className="form-control" id="Address" placeholder="Address"
                value={address}
                onChange={e => setAddress(e.target.value)} />
        </div>
        <div className="form-group">
            <label htmlFor="Salary">Salary</label>
            <input autoComplete="off" type="number" className="form-control" id="Salary" placeholder="Salary" 
                value={salary}
                onChange={e => setSalary(e.target.value)}/>
        </div>
        <div>
            <EmployeeQualification employeeQualificationList = {qualifications}
                setEmployeeQualificationList = {setQualification}/>
        </div>
        {
            savingEmployee ? <p>Saving ...</p> :
            <button type="submit" className="btn btn-primary" onClick={addEmployee}>Submit</button>
        }
        </div>
        </div>        
       </div>
    );
}
export default Employee;
