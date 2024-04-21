import React from "react";

export const ModelContext = React.createContext<string | undefined>("wind");

export function useModelContext() {
  return React.useContext(ModelContext);
}
