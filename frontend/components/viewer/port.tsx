"use client";
import React from "react";
import { Section } from "../ui/section";
import ViewerComp from "./viewer";
const Port: React.FC = () => {
  return (
    <div className="flex flex-1 gap-8">
      <ViewerComp url="https://latest.speckle.dev/streams/7b5d332115/objects/eefc4a1345a77fe0ac14f824a2375cb4" />
      <ViewerComp url="https://latest.speckle.dev/streams/9a079d8ace/objects/f65ad0c012674c9e2d26fcfd21a2d57f" />
    </div>
  );
};

export default Port;
