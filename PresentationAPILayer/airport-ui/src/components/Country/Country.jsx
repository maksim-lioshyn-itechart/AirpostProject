import "./Country.css";
import React from 'react';
import { BootstrapTable, TableHeaderColumn }
  from 'react-bootstrap-table'
import { onDeleteRow, onInsertRow, onSaveCell, fetchData } from './Actions';

export const countryModel = {
  id: String,
  name: String,
  code: String
};

class Country extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      hidden: true,
      countries: [countryModel]
    }
  }

  componentDidMount() {
    this.intervalCoordinateID = this.fetchData();
  }

  fetchData() {
    fetchData()
      .then(response => this.setState({
        countries: response
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
          data={this.state.countries}
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
          <TableHeaderColumn
            dataField='code'
            dataSort={true}>
            Code
          </TableHeaderColumn>
        </BootstrapTable>
      </div>
    )
  }
};

export default Country;
