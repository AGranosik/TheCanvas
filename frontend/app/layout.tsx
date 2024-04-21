"use client";
import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import Aside from "@/components/canvas/aside";
import Header from "@/components/canvas/header";
const inter = Inter({ subsets: ["latin"] });
import { Bot } from "lucide-react";

import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import Chat from "@/components/chat/chat";
import { useEffect, useState } from "react";
import { ModelContext } from "@/context/useModelContext";

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  const [model, setModel] = useState<string | undefined>(undefined);

  return (
    <html lang="en">
      <body className={inter.className}>
        <div className="grid h-screen w-full pl-[53px]">
          <Aside />
          <div className="flex flex-col">
            <ModelContext.Provider value={model}>
              <Header model={model} setModel={setModel} />
              {children}
            </ModelContext.Provider>
          </div>
          <div style={{ position: "absolute", bottom: "0px", left: "50%" }}>
            <Popover>
              <PopoverTrigger>
                <Bot />
              </PopoverTrigger>
              <PopoverContent style={{ width: "60vw", height: "70vh" }}>
                <Chat />
              </PopoverContent>
            </Popover>
          </div>
        </div>
      </body>
    </html>
  );
}
