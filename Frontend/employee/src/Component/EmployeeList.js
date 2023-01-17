import React, { useState,useEffect } from "react";

function EmployeeList(props){
    const {
            trigger,
            fetchingEmployeeQualification,
            employeeName,
            salary,
            address,
            setQualifications,
            selectedEmployeeId,
            setSelectedEmployeeId,
            resetValue
        } = props;

    const [employeeList,setEmployeeList] = useState([]);
    const [fetchingData, setFetchingData] = useState(false);
    const fetchEmployee = () => {
        setFetchingData(true);
        return fetch("https://localhost:44398/Employee")
        .then((response) => response.json())
        .then((data) => 
        {
            setEmployeeList(data);
            setFetchingData(false);
        });
    };

    const fetchEmployeeQualification = (id,index,details)=> {
        fetchingEmployeeQualification(true)
        setSelectedEmployeeId(id);
        setQualifications([]);
        return fetch("https://localhost:44398/Employee/"+id)
        .then((response) => response.json())
        .then((data) => 
        {
            employeeName(details.name);
            address(details.address);
            salary(details.salary);
            setQualifications(data.map(element => {
            var obj = {
                QualificationId: element.qualificationId,
                QualficationName: element.qualificationName,
                Marks: parseInt(element.marks),
                Remarks: element.remarks,
            };
            return obj;
           }));
           fetchingEmployeeQualification(false);
        });
    };

    useEffect(() => {
        fetchEmployee();
    },[]);

    useEffect(() => {
        if (trigger) {
            fetchEmployee();
        }
      }, [trigger]);

    return (
        <>
        {
            fetchingData ? <p>Loading....</p>  : 
            <div className="list-group" style={{
                height: "400px",
                overflow:"scroll"
            }}>
                {
                    employeeList.length === 0 ?
                    <p>No employee List</p> :
                    employeeList.map((x,i) => 
                    <a  
                        className={x.id === selectedEmployeeId 
                        ? "list-group-item list-group-item-action active" : "list-group-item list-group-item-action" }
                        onClick={() =>{
                            fetchEmployeeQualification(x.id,i,x)
                        }}
                         id={i} style={{cursor: "pointer"}} key={i}>{x.name}
                    </a>
                )}
            </div>
        }
        <hr></hr>
        <button type="button" className="btn btn-primary" style={{float: "right"}} onClick={()=> resetValue()}>Reset</button>

      </>
    );
}
export default EmployeeList;
