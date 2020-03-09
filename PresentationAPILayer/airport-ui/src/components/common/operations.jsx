import { url } from "../../config.js";

export function InsertRow(route, value) {
  return fetch(url + route, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(value)
  })
}

export async function SaveCell(route, value) {
  return await fetch(url + route, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(value)
  });
}

export function DeleteRow(route, key) {
  return fetch(url + route + "/" + key, {
        method: "DELETE"
      })
}

export async function FetchData(route) {
  return await fetch(url + route, {
      method: "GET",
      headers: { "Content-Type": "text/plain;charset=UTF-8" }
  })
      .then(r => r.json());
}