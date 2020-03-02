import React from 'react';
import { BootstrapTable, TableHeaderColumn }
  from 'react-bootstrap-table'

function onInsertRow(model) {
  fetch("https://localhost:44366/UserRoles", {
    method: "POST",
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(model.name)
  }).then(response => {
    if (response.ok) {
      alert('Added: ' + model.name)
    }
    throw new Error(response.statusText);
  })
}

function onSaveCell(value) {
  fetch("https://localhost:44366/UserRoles", {
    method: "PUT",
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(value)
  }).then(response => {
    if (response.ok) {
      alert('Updated: ' + value.name)
    }
    throw new Error(response.statusText);
  }
  )
}

function onDeleteRow(rowKeys) {
  rowKeys.map((key) => {
    fetch("https://localhost:44366/UserRoles/" + key,
      {
        method: "DELETE"
      });
  });
}

class UserRole extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      hidden: true,
      userRoles: []
    }
  }

  componentDidMount() {
    this.intervalCoordinateID = this.fetchData();
  }

  componentWillUnmount() {
  }

  async fetchData() {
    await fetch("https://localhost:44366/UserRoles", {
      method: "GET",
      headers: { "Content-Type": "text/plain;charset=UTF-8" }
    })
      .then(r => r.json())
      .then(response => this.setState({
        userRoles: response
      }));
  }

  render() {

    const options = {
      afterInsertRow: this.fetchData(),
      onAddRow: onInsertRow,
      onDeleteRow: onDeleteRow
    }

    const selectRowProp = {
      mode: 'checkbox'
    }

    const cellEditProp = {
      mode: 'click',
      afterSaveCell: onSaveCell,
      blurToSave: true
    }

    return (
      <div>
        <BootstrapTable
          keyField="id"
          data={this.state.userRoles}
          insertRow
          deleteRow
          selectRow={selectRowProp}
          cellEdit={cellEditProp}
          options={options}
        >
          <TableHeaderColumn
            hiddenOnInsert
            dataField='id'
            dataSort={true}
            hidden={this.state.hidden}>
            ID
          </TableHeaderColumn>
          <TableHeaderColumn
            dataField='name'
            dataSort={true}>
            Name
          </TableHeaderColumn>
        </BootstrapTable>
      </div>
    )
  }
}

export default UserRole;