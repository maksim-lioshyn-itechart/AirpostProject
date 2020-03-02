import { url } from '../../config.js';
import React from 'react';
import { BootstrapTable, TableHeaderColumn }
  from 'react-bootstrap-table'
import {onDeleteRow, onInsertRow, onSaveCell} from './actions';

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

  async fetchData() {
    await fetch(url + "UserRoles", {
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
      afterInsertRow: this.fetchData,
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
            hidden={this.state.hidden}
            autoValue>
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