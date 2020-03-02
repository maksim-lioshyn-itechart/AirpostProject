import { url } from "../../config.js";

export function InsertRow(api, value) {
  return fetch(url + api, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(value)
  })
}

export async function SaveCell(api, value) {
  return await fetch(url + api, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(value)
  });
}

export function DeleteRow(api, key) {
  return fetch(url + api + "/" + key,
      {
        method: "DELETE"
      })
}

export function FetchData(api){
  return fetch(url + api, {
      method: "GET",
      headers: { "Content-Type": "text/plain;charset=UTF-8" }
    });
}