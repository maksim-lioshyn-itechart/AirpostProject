import { InsertRow, SaveCell, DeleteRow, FetchData } from '../common/operations'
import { url } from "../../config.js";

export function onInsertRow(model) {
    InsertRow("UserRoles", model.name)
        .then(response => {
            if (response.ok) {
                alert('Added: ' + model.name)
            }
            throw new Error(response.statusText);
        })
}

export function onSaveCell(value) {
    SaveCell("UserRoles", value)
        .then(response => {
            if (response.ok) {
                alert('Updated: ' + value.name)
            }
            throw new Error(response.statusText);
        }
        )
}

export function onDeleteRow(rowKeys) {
    rowKeys.map(key => DeleteRow("UserRoles", key));
}