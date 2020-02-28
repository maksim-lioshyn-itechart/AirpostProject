import React from 'react';
import { BootstrapTable, TableHeaderColumn }
  from 'react-bootstrap-table'

function onInsertRow(row) {
  let newRowStr = ''

  
  for (const prop in row) {
    newRowStr += prop + ': ' + row[prop] + ' \n'
  }
  alert('You inserted:\n ' + newRowStr)
}


function onDeleteRow(rowKeys) {
  fetch("https://localhost:44366/UserRoles/" + rowKeys, {method: "DELETE"}).then((response) => {
      return response.json();
    }).then((result) => {
      // do what you want with the response here
    })

    console.log("https://localhost:44366/UserRoles/" + rowKeys);
  alert('You deleted: ' + rowKeys)
}



class UserRole extends React.Component {

  constructor(props) {
    super(props);
    this.state = { userRoles: [] }
  }

  componentDidMount() {
    this.intervalCoordinateID = this.fetchData();
  }

  componentWillUnmount() {
  }

  async fetchData() {
    const response = await fetch("https://localhost:44366/UserRoles", {
      method: "GET",
      headers: { "Content-Type": "text/plain;charset=UTF-8" }
    })
      .then(r => r.json());

    this.setState({
      userRoles: response
    });
  }

  renderTableData() {
    return this.state.userRoles.map((roles, index) => {
      const { id, name } = roles
      return (
        <tbody key={index}>
          <tr>
            <td>{id}</td>
            <td>{name}</td>
          </tr>
        </tbody>
      )
    })
  }

  render() {

    const options = {
      afterInsertRow: onInsertRow,
      afterDeleteRow: onDeleteRow
    }

    // To delete rows you be able to select rows
    const selectRowProp = {
      mode: 'checkbox'
    }

    return (
      <div>
        {/* <table className="userRoles" aria-label="test table">
          <thead>
            <tr>
              <td>Id</td>
              <td align="right">Name</td>
            </tr>
          </thead>
          {this.renderTableData()}
        </table> */}


        <BootstrapTable 
          data={this.state.userRoles}
          insertRow={true}
          deleteRow={true}
          selectRow={selectRowProp}
          options={options}
        >
          <TableHeaderColumn isKey dataField='id'>
            ID
          </TableHeaderColumn>
          <TableHeaderColumn dataField='name'>
            Name
          </TableHeaderColumn>
        </BootstrapTable>
      </div>
    )
  }
}

export default UserRole;