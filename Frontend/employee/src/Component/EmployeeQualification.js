import React, { useEffect, useState } from "react";

export default function EmployeeQualification(){
    const [qualification,setQualification] = useState([]);
    const fetchData = () => {
        return fetch("https://localhost:44398/Qualification")
            .then((response) => response.json())
            .then((data) => 
            {
                setQualification(data);
            });
      }
      useEffect(() => {
        fetchData();
      },[])
    return (
        <>
       <div className="containter" style={{paddingTop: "20px"}}>
            <div className="row">
                <div className="col-md-6">
                    <div className="row">
                        <div className="col-md-4" style={{ paddingTop: "7px"}}>
                            <p>Qualification</p>
                        </div>
                        <div className="col-md-8">
                            <select className="form-select">
                                {
                                qualification.map((x,i)=> 
                                    <option key={i} value={x.id}>{x.alias}</option>
                                )
                                }
                            </select>
                        </div>
                    </div>
                    <div>
                    </div>
                </div>
                <div className="col-md-3">
                <div className="row">
                        <div className="col-md-4" style={{ paddingTop: "7px"}}>
                            <p>Marks</p>
                        </div>
                        <div className="col-md-8">
                        <input type="text" className="form-control" id="Marks" placeholder="Marks" />
                        </div>
                    </div>
                </div>
                <div className="col-md-3">
                <div className="row">
                        <div className="col-md-4" style={{ paddingTop: "7px"}}>
                            <p>Remarks</p>
                        </div>
                        <div className="col-md-8">
                        <input type="text" className="form-control" id="Remarks" placeholder="Remarks" />
                        </div>
                    </div>
                </div>
            </div>
            <button type="submit" className="btn btn-primary" style={{float: "right"}}>Add</button>
          
       </div>
       <div className="containter"  style={{paddingTop: "30px"}}>
       <div className="row">
            <table className="table">
        <thead>
            <tr>
            <th scope="col">#</th>
            <th scope="col">Qualification</th>
            <th scope="col">Marks</th>
            <th scope="col">Remarks</th>
            </tr>
        </thead>
        <tbody>
            <tr>
            <th scope="row">1</th>
            <td>Mark</td>
            <td>Otto</td>
            <td>@mdo</td>
            <td>@mdo</td>
            </tr>
        </tbody>
        </table>
        </div>
       </div>
       </>
    );
}