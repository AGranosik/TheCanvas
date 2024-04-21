"use client";
import {
  Bird,
  ExternalLink,
  Rabbit,
  Settings,
  Share,
  Turtle,
} from "lucide-react";

import { Button } from "@/components/ui/button";
import {
  Drawer,
  DrawerContent,
  DrawerDescription,
  DrawerHeader,
  DrawerTitle,
  DrawerTrigger,
} from "@/components/ui/drawer";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
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
import Setting from "./buttons/setting";
import { useCallback } from "react";
import { on } from "events";

export default function Header({
  model,
  setModel,
}: {
  model: string | undefined;
  setModel: (model: string | undefined) => void;
}) {
  const onClick = useCallback(() => {
    navigator.clipboard.writeText(window.location.href);
  }, []);

  return (
    <header className="sticky top-0 z-10 flex h-[53px] items-center gap-1 border-b bg-background px-4">
      <h1 className="text-xl font-semibold">
        Canvas <Setting model={model} setModel={setModel} />
      </h1>

      <div className="ml-auto gap-1.5 text-sm">
        <Dialog>
          <DialogTrigger>
            <Button
              variant="outline"
              size="sm"
              className="ml-auto gap-1.5 text-sm"
              onClick={onClick}
            >
              <ExternalLink className="size-3.5" />
              Share
            </Button>
          </DialogTrigger>
          <DialogContent>
            <DialogHeader>
              <DialogTitle>Share with your friend and colleagues</DialogTitle>
              <DialogDescription>
                The link: {window.location.href} has been copied to your
                clipboard.
              </DialogDescription>
            </DialogHeader>
          </DialogContent>
        </Dialog>
      </div>
    </header>
  );
}
