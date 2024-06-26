"use client";
import React, { use } from "react";
import { Section } from "../ui/section";
import ViewerComp from "./viewer";
import { useModelContext } from "@/context/useModelContext";
import { ReferencedLinks } from "@/lib/links";
const Port: React.FC = () => {
  const model = useModelContext();
  console.log(model);

  if (!model) {
    return;
  }
  const links = ReferencedLinks[model || "wind"];

  return (
    <div className="flex flex-1 min-h-screen w-full">
      <ViewerComp url={links.model.now} />
      <ViewerComp url={links.model.then} />
    </div>
  );
};

export default Port;
