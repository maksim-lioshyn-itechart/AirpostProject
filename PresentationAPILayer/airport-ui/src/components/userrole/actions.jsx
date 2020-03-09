import { InsertRow, SaveCell, DeleteRow, FetchData } from '../common/operations';
import { Action } from '../../Enums/Action.jsx';
import { Api } from '../../Enums/Api.jsx';

export function onInsertRow(model) {
    InsertRow(Api.UserRole + Action.Post, { name: model.name })
        .then(response => {
            if (response.ok) {
                alert('Added: ' + model.name)
            }
            throw new Error(response.statusText);
        })
}

export function onSaveCell(value) {
    SaveCell(Api.UserRole + Action.Update, value)
        .then(response => {
            if (!response.ok) {
                throw new Error(response.statusText);
            }
        }
        )
}

export function onDeleteRow(rowKeys) {
    rowKeys.map(key => DeleteRow(Api.UserRole + Action.Delete, key));
}

export async function fetchData() {
    return FetchData(Api.UserRole + Action.Get);
}