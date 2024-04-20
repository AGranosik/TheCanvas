import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import Aside from "@/components/canvas/aside";
import Header from "@/components/canvas/header";
const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "Canvas",
  description: "Make a decision",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={inter.className}>
      <div className="grid h-screen w-full pl-[53px]">
      <Aside />
      <div className="flex flex-col">
        <Header />
        
        {children}    </div>
    </div></body>
    </html>
  );
}
