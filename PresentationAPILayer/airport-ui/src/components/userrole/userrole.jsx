import React from 'react';
import { BootstrapTable, TableHeaderColumn }
  from 'react-bootstrap-table'
import { onDeleteRow, onInsertRow, onSaveCell, fetchData } from './Actions';

export const userRoleModel = {
  id: String,
  name: String
};

class UserRole extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      hidden: true,
      userRoles: [userRoleModel]
    }
  }

  componentDidMount() {
    this.intervalCoordinateID = this.fetchData();
  }

  fetchData() {
    fetchData()
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
      blurToSave: true,
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