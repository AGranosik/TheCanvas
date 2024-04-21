"use client";
import {
  Bird,
  CornerDownLeft,
  Mic,
  Paperclip,
  Rabbit,
  Turtle,
} from "lucide-react";
import ViewerComp from "@/components/viewer/viewer";

import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";

import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Textarea } from "@/components/ui/textarea";
import {
  Tooltip,
  TooltipContent,
  TooltipTrigger,
  TooltipProvider,
} from "@/components/ui/tooltip";
import { useState } from "react";
import { getPromptResponse } from "@/api/promtpApi";

export default function Chat() {
  const [prompt, setPrompt] = useState("");
  const [response, setResponse] = useState("");

  const SendPrompt = async (event: any) => {
    console.log(prompt);
    event.preventDefault();
    let res = await getPromptResponse(prompt);
    setResponse(res.data);
  };

  return (
    <div className="relative flex h-full min-h-[50vh] flex-col rounded-xl bg-muted/50 p-4 lg:col-span-2">
      <div
        className="relative overflow-hidden rounded-lg border bg-background focus-within:ring-1 focus-within:ring-ring p-3"
        x-chunk="dashboard-03-chunk-1"
      >
        {response}
      </div>
      <div className="flex-1" />
      <form
        className="relative overflow-hidden rounded-lg border bg-background focus-within:ring-1 focus-within:ring-ring"
        x-chunk="dashboard-03-chunk-1"
      >
        <Label htmlFor="message" className="sr-only">
          Message
        </Label>
        <Textarea
          id="message"
          value={prompt}
          placeholder="Type your message here..."
          onChange={(e) => {
            setPrompt(e.currentTarget.value);
          }}
          className="min-h-12 resize-none border-0 p-3 shadow-none focus-visible:ring-0"
        />
        <div className="flex items-center p-3 pt-0">
          <TooltipProvider>
            <Tooltip>
              <TooltipTrigger asChild>
                <Button variant="ghost" size="icon">
                  <Paperclip className="size-4" />
                  <span className="sr-only">Attach file</span>
                </Button>
              </TooltipTrigger>
              <TooltipContent side="top">Attach File</TooltipContent>
            </Tooltip>
          </TooltipProvider>
          <TooltipProvider>
            <Tooltip>
              <TooltipTrigger asChild>
                <Button variant="ghost" size="icon">
                  <Mic className="size-4" />
                  <span className="sr-only">Use Microphone</span>
                </Button>
              </TooltipTrigger>
              <TooltipContent side="top">Use Microphone</TooltipContent>
            </Tooltip>
          </TooltipProvider>
          <Button
            type="submit"
            size="sm"
            className="ml-auto gap-1.5"
            onClick={(event) => SendPrompt(event)}
          >
            Send Message
            <CornerDownLeft className="size-3.5" />
          </Button>
        </div>
      </form>
    </div>
  );
}
