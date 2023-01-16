import React, { useState,useEffect } from "react";

function EmployeeList({trigger}){
    const [employeeList,setEmployeeList] = useState([]);
    const [fetchingData, setFetchingData] = useState(false);
    const [selectedEmployeeId, setSelectedEmployeeId] = useState(null);
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

    const deleteEmployee = (id,index) => {
        if(window.confirm("Do you want to delete this employee?")){
            const requestOptions = {
                method: 'DELETE',
                headers: {  'Accept': 'application/json','Content-Type': 'application/json' },
            };
            return fetch("https://localhost:44398/Employee/"+id,requestOptions).then((response) => response.json())
            .then((data) => 
            {
                fetchEmployee();
                //check if data is fetching from api or is on edit need to reset our input field.
                //call reset everything.
            });
        }
    };

    const fetchEmployeeQualification = (id,index)=> {
        setSelectedEmployeeId(id);
        //Fetch api for employee qualification
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
                        onClick={() =>fetchEmployeeQualification(x.id,i)}
                         id={i} style={{cursor: "pointer"}} key={i}>{x.name}
                        <i className="bi bi-x-circle-fill" style={{ float: "right"}} title="Remove Employee" onClick={()=> deleteEmployee(x.id)}></i>
                    </a>
                )}
            </div>
        }
        <hr></hr>
        <button type="button" className="btn btn-primary" style={{float: "right"}}>Reset</button>

      </>
    );
}
export default EmployeeList;
