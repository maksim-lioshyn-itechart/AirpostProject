import { InsertRow, SaveCell, DeleteRow } from '../common/operations';

export function onInsertRow(model) {
    InsertRow("UserRole/Post", { name: model.name })
        .then(response => {
            if (response.ok) {
                alert('Added: ' + model.name)
            }
            throw new Error(response.statusText);
        })
}
export function onSaveCell(value) {
    SaveCell("UserRole/Update", value)
        .then(response => {
            if (!response.ok) {
                throw new Error(response.statusText);
            }
        }
        )
}

export function onDeleteRow(rowKeys) {
    rowKeys.map(key => DeleteRow("UserRole/Delete", key));
}